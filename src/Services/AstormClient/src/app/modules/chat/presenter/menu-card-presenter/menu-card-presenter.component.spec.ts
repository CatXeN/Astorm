import { ComponentFixture, TestBed } from '@angular/core/testing';

import { MenuCardPresenterComponent } from './menu-card-presenter.component';

describe('MenuCardPresenterComponent', () => {
  let component: MenuCardPresenterComponent;
  let fixture: ComponentFixture<MenuCardPresenterComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ MenuCardPresenterComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(MenuCardPresenterComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
