import { Component, Input, OnInit } from '@angular/core';
import { ImgSanitizerService } from '../../../services/imgSanitizerService';
import { SafeUrl } from '@angular/platform-browser';
import { CommonModule } from '@angular/common';
import { RouterModule } from '@angular/router';

@Component({
  selector: 'app-sidebar',
  standalone: true,
  imports: [CommonModule, RouterModule],
  templateUrl: './sidebar.component.html',
  styleUrl: './sidebar.component.scss'
})
export class SidebarComponent implements OnInit {
  @Input() isAuthorized!: boolean;
  @Input() isAdmin!: boolean;

  constructor() { 
    console.log(this.isAuthorized);
  }

  ngOnInit(): void {
   
  }
}
