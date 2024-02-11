import { Component } from '@angular/core';
import { InputTextModule } from 'primeng/inputtext';
import { ButtonModule } from 'primeng/button';
import { FormsModule } from '@angular/forms';
import { Router } from '@angular/router';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { ToastModule } from 'primeng/toast';
import { MessageService } from 'primeng/api';
import { environment } from '../../environments/environment';
import { InputGroupModule } from 'primeng/inputgroup';
import { InputGroupAddonModule } from 'primeng/inputgroupaddon';

@Component({
  selector: 'app-login',
  standalone: true,
  imports: [
    InputTextModule,
    ButtonModule,
    FormsModule,
    ToastModule,
    InputGroupModule,
    InputGroupAddonModule
  ],
  templateUrl: './login.component.html',
  styleUrl: './login.component.scss'
})
export class LoginComponent {
  constructor(
    private router: Router,
    private http: HttpClient,
    private messageService: MessageService) { }
  value: any;

  async onSubmit(form: any) {
    console.log(form);
    const response = await this.postData(form.value.username)
    if (response.statusCode == 200) {
      localStorage.setItem('user', form.value.username);
      this.messageService.add({ severity: 'success', summary: 'Success', detail: 'Logged in successfully' });
      setTimeout(() => {
        this.router.navigate(['/chart']);
      }, 1500);
    }
    else {
      this.messageService.add({ severity: 'error', summary: 'Error', detail: 'Something went wrong! Please try again.' });
    }
  }

  async postData(username: string): Promise<any> {
    const url = environment.baseApiUrl + environment.loginUrl;
    const data = { username: username };
    const headers = new HttpHeaders({
      'Content-Type': 'application/json',
      "user": username
      // 'Authorization': ''
    });

    try {
      //TODO remove this and use proper observalbe pattern
      //Using toPromise() to convert an observable to a promise is a necessary workaround for the current version of Angular. if you want to use the async await pattern otherwise the request will not be sent.Even though angular should internally make a call to toPromise() when using await, it does not.
      return await this.http.post(url, data, { headers }).toPromise();
    } catch (error) {
      console.error('An error occurred: ', error);
      throw error;
    }
  }
}
