import { Component, OnInit } from '@angular/core';
import { CommonModule } from '@angular/common';
import { HttpClient, HttpErrorResponse } from '@angular/common/http';
import { FormGroup, FormControl, ReactiveFormsModule, Validators } from '@angular/forms';

interface AlunoDto {
  id: number;
  nome: string;
  dataNascimento: string; // ISO
  email?: string | null;
  ativo: boolean;
  matriculas?: Array<any> | null;
}

@Component({
  selector: 'app-blue',
  standalone: true,
  imports: [CommonModule, ReactiveFormsModule],
  template: `
    <main style="padding:24px">
      <h2>Alunos Cadastrados</h2>
      <div *ngIf="error" style="color:#b00020">{{ error }}</div>
      <div style="margin-top:12px;margin-bottom:12px">
        <button (click)="showForm = !showForm">{{ showForm ? 'Cancelar' : 'Registrar novo aluno' }}</button>
      </div>

      <form *ngIf="showForm" [formGroup]="createForm" (ngSubmit)="onCreate()" style="margin-bottom:16px;border:1px solid #ddd;padding:12px;border-radius:6px">
        <div style="display:flex;gap:12px;flex-wrap:wrap">
          <div style="flex:1">
            <label>Nome</label>
            <input formControlName="nome" />
          </div>
          <div style="width:180px">
            <label>Data Nascimento</label>
            <input type="date" formControlName="dataNascimento" />
          </div>
          <div style="width:260px">
            <label>Email</label>
            <input formControlName="email" />
          </div>
          <div style="width:120px;display:flex;align-items:center;gap:6px">
            <label>Ativo</label>
            <input type="checkbox" formControlName="ativo" />
          </div>
        </div>
        <div style="margin-top:12px">
          <button type="submit" [disabled]="createForm.invalid || creating">Salvar</button>
        </div>
      </form>
      <table *ngIf="alunos" border="1" cellpadding="8" cellspacing="0" style="width:100%;border-collapse:collapse;margin-top:12px">
        <thead style="background:#f3f3f3">
          <tr>
            <th>Nome</th>
            <th>Data Nascimento</th>
            <th>Email</th>
            <th>Ativo</th>
            <th># Matriculas</th>
          </tr>
        </thead>
        <tbody>
          <tr *ngFor="let a of alunos">
            <td>{{ a.nome }}</td>
            <td>{{ formatDate(a.dataNascimento) }}</td>
            <td>{{ a.email || '-' }}</td>
            <td>{{ a.ativo ? 'Sim' : 'Não' }}</td>
            <td>{{ (a.matriculas || []).length }}</td>
          </tr>
        </tbody>
      </table>
      <div *ngIf="!alunos && !error">Carregando...</div>
    </main>
  `
})
export class BlueComponent implements OnInit {
  alunos: AlunoDto[] | null = null;
  error: string | null = null;
  showForm = false;
  creating = false;

  createForm = new FormGroup({
    nome: new FormControl('', Validators.required),
    dataNascimento: new FormControl(''),
    email: new FormControl(''),
    ativo: new FormControl(true)
  });

  constructor(private http: HttpClient) {}

  ngOnInit(): void {
    this.loadAlunos();
  }

  async onCreate() {
    if (this.createForm.invalid) return;
    this.creating = true;
    this.error = null;
    const body = {
      nome: this.createForm.value.nome,
      dataNascimento: this.createForm.value.dataNascimento,
      email: this.createForm.value.email,
      ativo: this.createForm.value.ativo
    };
    try {
      await this.http.post('/api/alunos', body).toPromise();
      this.showForm = false;
      this.createForm.reset({ ativo: true });
      // recarrega lista
      this.loadAlunos();
    } catch (err: any) {
      this.error = `Erro criando aluno: ${err?.status || ''} ${err?.message || err?.toString()}`;
    } finally {
      this.creating = false;
    }
  }

  private loadAlunos() {
  this.http.get<AlunoDto[]>('/api/alunos').subscribe({
      next: (data) => {
        // map property names in API response to our DTO if needed
        this.alunos = data.map(d => ({
          id: (d as any).id ?? 0,
          nome: (d as any).nome ?? (d as any).Nome ?? '',
          dataNascimento: (d as any).dataNascimento ?? (d as any).DataNascimento ?? (d as any).dataNascimento,
          email: (d as any).email ?? (d as any).Email ?? null,
          ativo: (d as any).ativo ?? (d as any).Ativo ?? false,
          matriculas: (d as any).matriculas ?? (d as any).Matriculas ?? []
        }));
      },
      error: (err: HttpErrorResponse) => {
        this.error = `Erro ao carregar alunos: ${err.status} ${err.statusText}`;
      }
    });
  }

  formatDate(iso: string | undefined) {
    if (!iso) return '-';
    try {
      const d = new Date(iso);
      return d.toLocaleDateString();
    } catch {
      return iso;
    }
  }
}
