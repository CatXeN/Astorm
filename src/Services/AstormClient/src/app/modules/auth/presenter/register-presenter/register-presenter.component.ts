import { Component, OnInit } from '@angular/core';
import { FormControl, FormGroup } from '@angular/forms';
import { Router } from '@angular/router';
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
    password: new FormControl('')
  });


  constructor(private authService: AuthService, private route: Router) { }

  ngOnInit(): void {
  }

  register() {
    this.authService.register(this.registerForm.value).subscribe(x => {
      this.route.navigate(['auth/login'])
    })
  }
}

