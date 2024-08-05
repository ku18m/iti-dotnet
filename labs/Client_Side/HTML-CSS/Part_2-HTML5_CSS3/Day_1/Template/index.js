window.onload = function() {
    let accentPicker = document.getElementById('accentPicker');
    let savedAccent = localStorage.getItem('accent');
    if (savedAccent) {
        setAccent(savedAccent);
        setAccentPicker(savedAccent);
    }

    accentPicker.addEventListener('change', changeAccentPickerEvent);
}

// Accent picker changed.
function changeAccentPickerEvent() {
    let accent = document.getElementById('accentPicker').value;
    saveAccent(accent);
    setAccent(accent);
}

// Save accent to local storage.
function saveAccent(accent) {
    localStorage.setItem('accent', accent);
}

function setAccent(accent) {
    document.documentElement.style.setProperty('--accent', accent);
}


function setAccentPicker(accent) {
    document.getElementById('accentPicker').value = accent;
}