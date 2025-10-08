import { Component, signal } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FormControl, FormGroup, ReactiveFormsModule, Validators } from '@angular/forms';
import { Router } from '@angular/router';
import { AuthService } from './auth.service';

@Component({
  selector: 'app-login',
  standalone: true,
  imports: [CommonModule, ReactiveFormsModule],
  template: `
    <main style="display:flex;min-height:100vh;align-items:center;justify-content:center;">
      <form [formGroup]="form" (ngSubmit)="onSubmit()" style="width:320px;padding:24px;border-radius:8px;box-shadow:0 6px 18px rgba(0,0,0,.08)">
        <h2>Entrar</h2>
        <div>
          <label>Usuário</label>
          <input formControlName="username" />
        </div>
        <div style="margin-top:8px;">
          <label>Senha</label>
          <input type="password" formControlName="password" />
        </div>
        <div style="margin-top:12px;">
          <button type="submit" [disabled]="loading()">Fazer login</button>
        </div>
  <div *ngIf="error()" style="color:#b00020;margin-top:8px">{{ error() }}</div>
      </form>
    </main>
  `
})
export class LoginComponent {
  protected loading = signal(false);
  protected error = signal<string | null>(null);

  form = new FormGroup({
    username: new FormControl('', Validators.required),
    password: new FormControl('', Validators.required)
  });

  constructor(private auth: AuthService, private router: Router) {}

  async onSubmit() {
    if (this.form.invalid) return;
    this.loading.set(true);
    this.error.set(null);
    try {
      const { username, password } = this.form.value as any;
      await this.auth.login(username, password);
      // navegar para tela azul
      await this.router.navigate(['/blue']);
    } catch (err: any) {
      this.error.set(err?.message || 'Erro ao fazer login');
    } finally {
      this.loading.set(false);
    }
  }
}
