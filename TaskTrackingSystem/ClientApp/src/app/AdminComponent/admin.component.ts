import { Component } from "@angular/core";
import { Router } from "@angular/router";

@Component({
  selector: 'admin',
  templateUrl: './admin.component.html',
  styleUrls: ['./admin.component.css'],
})
export class AdminComponent {
  constructor(private router: Router) {
    if (localStorage.getItem("role") !== "Admin") {
      this.router.navigateByUrl("");
    }
  }

  signOut() {
    localStorage.clear();
    this.router.navigateByUrl("");
  }

  showUsersList() {
    this.router.navigateByUrl("admin/users");
  }

  showProjectsList() {
    this.router.navigateByUrl("admin");
  }
}
