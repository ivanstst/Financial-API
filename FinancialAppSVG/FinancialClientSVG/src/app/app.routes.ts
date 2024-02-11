import { Routes } from '@angular/router';
import { LoginComponent } from './login/login.component';
import { ChartComponent } from './chart/chart.component';
import { SavedViewsComponent } from './list-view/list-view.component';
import { AuthGuard } from './services/auth.guard.service';

export const routes: Routes = [
    { path: '', redirectTo: 'login', pathMatch: 'full'},
    { path: 'login', component: LoginComponent },
    { path: 'chart', component: ChartComponent, canActivate: [AuthGuard] },
    { path: 'list-view', component: SavedViewsComponent, canActivate: [AuthGuard] },
    { path: '**', redirectTo: 'login'}
];
