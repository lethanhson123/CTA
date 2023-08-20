import { ComponentFixture, TestBed } from '@angular/core/testing';

import { CategoryIdeasComponent } from './category-ideas.component';

describe('CategoryIdeasComponent', () => {
  let component: CategoryIdeasComponent;
  let fixture: ComponentFixture<CategoryIdeasComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ CategoryIdeasComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(CategoryIdeasComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
