import { Component, OnInit } from '@angular/core';
import { FormControl, FormGroup } from '@angular/forms';
import { Router } from '@angular/router';
import { AuthService } from '../../service/auth.service';

@Component({
  selector: 'app-login-presenter',
  templateUrl: './login-presenter.component.html',
  styleUrls: ['./login-presenter.component.scss']
})
export class LoginPresenterComponent {

  hide = true;

  loginForm = new FormGroup({
    username: new FormControl(''),
    password: new FormControl('')
  });

  constructor(private auth: AuthService, private route: Router) { }

  loginto() {
    this.auth.login(this.loginForm.value).subscribe(x => {
      this.route.navigate(['/chat']);
    });
  }

}
