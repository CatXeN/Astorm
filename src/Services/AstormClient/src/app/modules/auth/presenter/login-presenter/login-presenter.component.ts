import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-login-presenter',
  templateUrl: './login-presenter.component.html',
  styleUrls: ['./login-presenter.component.scss']
})
export class LoginPresenterComponent implements OnInit {

  hide = true;

  constructor() { }

  ngOnInit(): void {
  }

}
