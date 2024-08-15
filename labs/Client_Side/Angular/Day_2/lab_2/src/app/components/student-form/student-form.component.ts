import { CommonModule } from '@angular/common';
import { Component } from '@angular/core';
import { FormsModule } from '@angular/forms';

@Component({
  selector: 'app-student-form',
  standalone: true,
  imports: [CommonModule, FormsModule],
  templateUrl: './student-form.component.html',
  styleUrl: './student-form.component.css'
})
export class StudentFormComponent {
  studentName: string = '';
  studentAge: number = 0;
  students: Student[] = [];
  isValidName: boolean = true;
  isValidAge: boolean = true;

  addStudent() {
    this.isValidName = this.studentName.length > 0;
    this.isValidAge = this.studentAge > 0;
    if (this.isValidName && this.isValidAge) {
      this.students.push(new Student(this.studentName, this.studentAge));
      this.studentName = '';
      this.studentAge = 0;
    }
  }

  removeStudent(index: number) {
    this.students.splice(index, 1);
  }

  validateName() {
    this.isValidName = this.studentName.length > 3;
  }

  validateAge() {
    this.isValidAge = this.studentAge > 18;
  }
}


class Student {
  constructor(public name: string, public age: number) {
  }
}