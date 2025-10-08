import { Injectable, inject } from '@angular/core';
import { HttpHandler, HttpInterceptor, HttpRequest, HttpEvent } from '@angular/common/http';
import { Observable } from 'rxjs';

@Injectable()
export class AuthInterceptor implements HttpInterceptor {
  intercept(req: HttpRequest<unknown>, next: HttpHandler): Observable<HttpEvent<unknown>> {
    try {
      const token = localStorage.getItem('auth_token');
      console.debug('[AuthInterceptor] token=', token, 'for request', req.url);
      if (token) {
        const cloned = req.clone({
          setHeaders: {
            Authorization: `Bearer ${token}`
          }
        });
        console.debug('[AuthInterceptor] adding Authorization header for', req.url);
        return next.handle(cloned);
      }
    } catch (e) {
      console.debug('[AuthInterceptor] error reading token', e);
    }
    return next.handle(req);
  }
}
