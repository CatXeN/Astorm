import { ComponentFixture, TestBed } from '@angular/core/testing';

import { ChatCardPresenterComponent } from './chat-card-presenter.component';

describe('ChatCardPresenterComponent', () => {
  let component: ChatCardPresenterComponent;
  let fixture: ComponentFixture<ChatCardPresenterComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ ChatCardPresenterComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(ChatCardPresenterComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
