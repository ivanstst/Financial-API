import { Injectable } from '@angular/core';
import { Router } from '@angular/router';

@Injectable({ providedIn: 'root' })
export class AuthGuard {
    constructor(private router: Router) { }
    canActivate() {
        // localStorage.clear();
        let authenticatedUser = localStorage.getItem('user');
        if (
            authenticatedUser !== undefined && authenticatedUser !== null
        ) {
            return true;
        }
        this.router.navigate(['/login']);
        return false;
    }

}
