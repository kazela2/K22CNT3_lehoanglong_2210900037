// script.js
const playBtn = document.getElementById('playBtn');
const videoContainer = document.getElementById('videoContainer');
const video = document.getElementById('video');
const closeBtn = document.getElementById('closeBtn');

// Hiện video khi nhấn nút Play
playBtn.addEventListener('click', () => {
    videoContainer.style.display = 'block'; // Hiển thị video
    video.play(); // Phát video
});

// Đóng video
closeBtn.addEventListener('click', () => {
    videoContainer.style.display = 'none'; // Ẩn video
    video.pause(); // Dừng video
    video.currentTime = 0; // Quay lại đầu video
});
