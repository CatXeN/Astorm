import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { SharedModule } from 'src/app/shared/shared.module';
import { AuthContainerComponent } from './container/auth-container/auth-container.component';
import { LoginPresenterComponent } from './presenter/login-presenter/login-presenter.component';
import { RegisterPresenterComponent } from './presenter/register-presenter/register-presenter.component';
import { AuthRoutingModule } from './auth-routing.module';



@NgModule({
  declarations: [AuthContainerComponent, LoginPresenterComponent, RegisterPresenterComponent],
  imports: [
    CommonModule,
    SharedModule,
    AuthRoutingModule
  ]
})
export class AuthModule { }
