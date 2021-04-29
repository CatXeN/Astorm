import { ComponentFixture, TestBed } from '@angular/core/testing';

import { FriendsContainerComponent } from './friends-container.component';

describe('FriendsContainerComponent', () => {
  let component: FriendsContainerComponent;
  let fixture: ComponentFixture<FriendsContainerComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ FriendsContainerComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(FriendsContainerComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
