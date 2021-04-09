import { Component } from '@angular/core';
import { TranslateService } from '@ngx-translate/core';

@Component({
  selector: 'app-toolbar',
  templateUrl: './toolbar.component.html',
  styleUrls: ['./toolbar.component.scss']
})
export class ToolbarComponent {

  constructor(private translate: TranslateService) {
    translate.setDefaultLang('en');
  }
  
  switchLanguage(language: string): void {
    this.translate.use(language);
  }
}
