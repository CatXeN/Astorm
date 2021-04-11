import { ComponentFixture, TestBed } from '@angular/core/testing';

import { FriendsCardPresenterComponent } from './friends-card-presenter.component';

describe('FriendsCardPresenterComponent', () => {
  let component: FriendsCardPresenterComponent;
  let fixture: ComponentFixture<FriendsCardPresenterComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ FriendsCardPresenterComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(FriendsCardPresenterComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
