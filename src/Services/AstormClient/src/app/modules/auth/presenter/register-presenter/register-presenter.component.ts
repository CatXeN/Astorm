import { Component, OnInit } from '@angular/core';
import { FormControl, FormGroup } from '@angular/forms';
import { Router } from '@angular/router';
import moment from 'moment';
import { Register } from 'src/app/shared/models/register.model';
import { AuthService } from '../../service/auth.service';

@Component({
  selector: 'app-register-presenter',
  templateUrl: './register-presenter.component.html',
  styleUrls: ['./register-presenter.component.scss']
})
export class RegisterPresenterComponent implements OnInit {

  hide: boolean;

  registerForm = new FormGroup({
    username: new FormControl(''),
    password: new FormControl(''),
    email: new FormControl(''),
    birthDate: new FormControl('')
  });

  constructor(private authService: AuthService, private route: Router) { }

  ngOnInit(): void {
  }

  register() {

    let json: Register = {
      username: this.registerForm.controls['username'].value,
      password: this.registerForm.controls['password'].value,
      attributes: [
        {
          key: 'email',
          value: this.registerForm.controls['email'].value
        },
        {
          key: 'birthdate',
          value: moment(this.registerForm.controls["birthDate"].value).format('YYYY-MM-DD')
        }
      ]
    }
    this.authService.register(json).subscribe(x => {
      this.route.navigate(['auth/login'])
    })
  }
}

