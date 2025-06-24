function toggleAdvancedFilters() {
    const content = document.getElementById('advancedFilterContent');
    const icon = document.getElementById('advancedFilterIcon');
    const isHidden = content.classList.toggle('hidden');
    icon.style.transform = isHidden ? '' : 'rotate(180deg)';
    icon.querySelector('i').classList.toggle('ri-arrow-down-s-line', isHidden);
    icon.querySelector('i').classList.toggle('ri-arrow-up-s-line', !isHidden);
}