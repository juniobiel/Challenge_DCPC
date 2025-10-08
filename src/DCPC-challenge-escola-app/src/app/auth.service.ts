import { inject, Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Router } from '@angular/router';
import { firstValueFrom } from 'rxjs';

export interface LoginResponse {
  token: string;
}

@Injectable({ providedIn: 'root' })
export class AuthService {
  private http = inject(HttpClient);
  private router = inject(Router);

  async login(username: string, password: string): Promise<void> {
  const url = '/api/account/login';
    const body = { username, password } as any;
    const res = await firstValueFrom(this.http.post<LoginResponse | any>(url, body));
    const token = (res && ((res as any).token || (res as any).access_token)) as string | undefined;
    if (token) {
      localStorage.setItem('auth_token', token);
    } else {
      throw new Error('Token não retornado pelo servidor');
    }
  }

  logout() {
    localStorage.removeItem('auth_token');
    this.router.navigate(['/login']);
  }

  get token(): string | null {
    return localStorage.getItem('auth_token');
  }
}
