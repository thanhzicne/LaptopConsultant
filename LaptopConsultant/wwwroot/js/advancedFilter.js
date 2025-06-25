
function toggleAdvancedFilters() {
    const content = document.getElementById('advancedFilterContent');
    const icon = document.getElementById('advancedFilterIcon');
    
    if (!content || !icon) {
        console.error('Không tìm thấy advancedFilterContent hoặc advancedFilterIcon');
        return;
    }

    const isHidden = content.classList.toggle('hidden');
    icon.style.transform = isHidden ? '' : 'rotate(180deg)';
    icon.querySelector('i').classList.toggle('ri-arrow-down-s-line', isHidden);
    icon.querySelector('i').classList.toggle('ri-arrow-up-s-line', !isHidden);

    // Lưu trạng thái vào sessionStorage
    sessionStorage.setItem('advancedFilterState', isHidden ? 'closed' : 'open');
}

// Khôi phục trạng thái khi tải trang
document.addEventListener('DOMContentLoaded', () => {
    const content = document.getElementById('advancedFilterContent');
    const icon = document.getElementById('advancedFilterIcon');
    if (content && icon && sessionStorage.getItem('advancedFilterState') === 'open') {
        content.classList.remove('hidden');
        icon.style.transform = 'rotate(180deg)';
        icon.querySelector('i').classList.remove('ri-arrow-down-s-line');
        icon.querySelector('i').classList.add('ri-arrow-up-s-line');
    }
});
