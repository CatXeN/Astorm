import { ComponentFixture, TestBed } from '@angular/core/testing';

import { LoginPresenterComponent } from './login-presenter.component';

describe('LoginPresenterComponent', () => {
  let component: LoginPresenterComponent;
  let fixture: ComponentFixture<LoginPresenterComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ LoginPresenterComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(LoginPresenterComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
