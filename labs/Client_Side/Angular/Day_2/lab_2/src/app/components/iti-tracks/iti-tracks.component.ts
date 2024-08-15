import { Component } from '@angular/core';
import { FormsModule } from '@angular/forms';

@Component({
  selector: 'app-iti-tracks',
  standalone: true,
  imports: [FormsModule],
  templateUrl: './iti-tracks.component.html',
  styleUrl: './iti-tracks.component.css'
})
export class ItiTracksComponent {
  itiTracks: { [key: string]: string[] } = {
    '.NET': ['Menofia', 'Cairo', 'Alex'],
    'Java': ['Assuit', 'Tanta'],
    'PHP': ['Menofia', 'Assuit', 'Ismailia'],
    'Python': [],
  }
  selectedTrack: string = '';

  get tracks() {
    return Object.keys(this.itiTracks);
  }
}
