let currentIndex = 0;
const images = document.querySelectorAll('.image-box img');
const totalImages = images.length;
const contentText = document.getElementById('content-text');

document.getElementById('nextBtn').addEventListener('click', () => {
  changeImage(1);
});

document.getElementById('prevBtn').addEventListener('click', () => {
  changeImage(-1);
});

// Chức năng thay đổi ảnh
function changeImage(direction) {
  images[currentIndex].classList.remove('active');
  currentIndex = (currentIndex + direction + totalImages) % totalImages;
  images[currentIndex].classList.add('active');
  updateContent(images[currentIndex]);
}

