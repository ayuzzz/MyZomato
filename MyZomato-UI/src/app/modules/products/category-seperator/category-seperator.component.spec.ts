import { ComponentFixture, TestBed } from '@angular/core/testing';

import { CategorySeperatorComponent } from './category-seperator.component';

describe('CategorySeperatorComponent', () => {
  let component: CategorySeperatorComponent;
  let fixture: ComponentFixture<CategorySeperatorComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ CategorySeperatorComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(CategorySeperatorComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
