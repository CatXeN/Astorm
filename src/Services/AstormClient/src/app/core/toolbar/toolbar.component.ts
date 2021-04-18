import { Component, OnInit } from '@angular/core';
import { TranslateService } from '@ngx-translate/core';
import { UserService } from 'src/app/shared/services/user.service';

@Component({
  selector: 'app-toolbar',
  templateUrl: './toolbar.component.html',
  styleUrls: ['./toolbar.component.scss']
})
export class ToolbarComponent implements OnInit {

  username: string;
  userId: string;
  status = 1;

  constructor(private translate: TranslateService, private userService: UserService) {
    translate.setDefaultLang('en');
  }

  ngOnInit() {
    this.username = localStorage.getItem("name");
    this.userId = localStorage.getItem('id');
  }

  switchLanguage(language: string): void {
    this.translate.use(language);
  }

  setStatus(status: number) {
    this.userService.changeStatus(status, this.userId).subscribe(x => {
      this.status = status;
    });
  }
}
