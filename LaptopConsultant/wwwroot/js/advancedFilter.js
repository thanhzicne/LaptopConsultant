document.addEventListener('DOMContentLoaded', function () {
    const advancedFilterBtn = document.getElementById('advancedFilterBtn');
    const advancedFilterPanel = document.getElementById('advancedFilterPanel');
    if (advancedFilterBtn && advancedFilterPanel) {
        advancedFilterBtn.addEventListener('click', () => {
            advancedFilterPanel.classList.toggle('hidden');
        });
    }
});