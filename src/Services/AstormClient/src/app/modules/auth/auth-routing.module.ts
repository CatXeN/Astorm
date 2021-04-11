import { NgModule } from "@angular/core";
import { RouterModule, Routes } from "@angular/router";
import { AuthContainerComponent } from "./container/auth-container/auth-container.component";
import { LoginPresenterComponent } from "./presenter/login-presenter/login-presenter.component";
import { RegisterPresenterComponent } from "./presenter/register-presenter/register-presenter.component";

export const routes: Routes = [
  {
    path: '',
    component: AuthContainerComponent,
    children: [
      {
        path: 'login',
        component: LoginPresenterComponent
      },
      {
        path: 'register',
        component: RegisterPresenterComponent
      }
    ]
  }

]

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class AuthRoutingModule { }
