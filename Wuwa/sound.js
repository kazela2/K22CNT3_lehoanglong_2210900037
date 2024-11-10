// Lấy phần tử nút và âm thanh
const soundBtn = document.getElementById('soundBtn');
const audio = document.getElementById('audio');

let isPlaying = false;

// Khi nhấn nút, phát hoặc dừng nhạc
soundBtn.addEventListener('click', () => {
    if (isPlaying) {
        audio.pause();  // Dừng nhạc
        isPlaying = false;
    } else {
        audio.play();  // Phát nhạc
        isPlaying = true;
    }
});
