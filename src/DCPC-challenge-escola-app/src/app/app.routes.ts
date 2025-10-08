import { Routes } from '@angular/router';
import { importProvidersFrom } from '@angular/core';
import { BlueComponent } from './blue.component';
import { LoginComponent } from './login.component';

export const routes: Routes = [
	{ path: '', pathMatch: 'full', redirectTo: 'login' },
	{ path: 'login', component: LoginComponent },
	{ path: 'blue', component: BlueComponent },
	{ path: '**', redirectTo: 'login' }
];
