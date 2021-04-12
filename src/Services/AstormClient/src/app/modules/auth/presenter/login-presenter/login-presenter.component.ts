import { Component, OnInit } from '@angular/core';
import { FormControl, FormGroup } from '@angular/forms';
import { AuthService } from '../../service/auth.service';

@Component({
  selector: 'app-login-presenter',
  templateUrl: './login-presenter.component.html',
  styleUrls: ['./login-presenter.component.scss']
})
export class LoginPresenterComponent implements OnInit {

  hide = true;

  loginForm = new FormGroup({
    username: new FormControl(''),
    password: new FormControl('')
  });

  constructor(private auth: AuthService) { }

  ngOnInit(): void {
  }

  loginto() {
    console.log(this.loginForm.value);
    this.auth.login(this.loginForm.value).subscribe(x => console.log(x));
  }

}
