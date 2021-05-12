import { Component, NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { MainLayoutComponent } from './core/main-layout/main-layout.component';

const routes: Routes = [
  {
    path: 'chat',
    component: MainLayoutComponent,
    children: [
      {
        path: '',
        loadChildren: () => import('./modules/chat/chat.module').then(x => x.ChatModule)
      },
      {
        path: 'friends',
        loadChildren: () => import('./modules/friends/friends.module').then(x => x.FriendsModule)
      }
    ]
  },
  {
    path: 'auth',
    children: [
      {
        path: '',
        loadChildren: () => import('./modules/auth/auth.module').then(a => a.AuthModule)
      }
    ]
  },
  {
    path: '**',
    redirectTo: '/auth/login'

  },
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
