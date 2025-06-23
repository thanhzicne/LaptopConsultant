document.addEventListener('DOMContentLoaded', function () {
    const dropdowns = document.querySelectorAll('.dropdown');
    dropdowns.forEach(dropdown => {
        const button = dropdown.querySelector('.dropdown-toggle');
        const menu = dropdown.querySelector('.dropdown-menu');
        button.addEventListener('click', () => {
            menu.classList.toggle('hidden');
            menu.classList.toggle('opacity-0');
            menu.classList.toggle('opacity-100');
            menu.classList.toggle('transform');
            menu.classList.toggle('-translate-y-1');
        });
        document.addEventListener('click', (e) => {
            if (!dropdown.contains(e.target)) {
                menu.classList.add('hidden');
                menu.classList.add('opacity-0');
                menu.classList.remove('opacity-100');
                menu.classList.add('transform');
                menu.classList.add('-translate-y-1');
            }
        });
    });
});