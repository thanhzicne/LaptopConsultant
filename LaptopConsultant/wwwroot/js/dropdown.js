
document.addEventListener('DOMContentLoaded', function () {
    const dropdowns = document.querySelectorAll('.sortDropdown');
    dropdowns.forEach(dropdown => {
        const button = dropdown.querySelector('.sort-dropdown');
        const menu = dropdown.querySelector('.dropdown-menu');
        
        if (!button || !menu) {
            console.error('Không tìm thấy button hoặc menu trong dropdown');
            return;
        }

        button.addEventListener('click', () => {
            menu.classList.toggle('hidden');
            menu.classList.toggle('opacity-0');
            menu.classList.toggle('opacity-100');
            menu.classList.toggle('transform');
            menu.classList.toggle('-translate-y-1');
        });

        // Xử lý khi chọn tùy chọn sắp xếp
        menu.querySelectorAll('.sort-option').forEach(option => {
            option.addEventListener('click', () => {
                const sortValue = option.getAttribute('data-value');
                document.getElementById('sortSelected').textContent = option.querySelector('span').textContent;
                menu.classList.add('hidden');
                menu.classList.add('opacity-0');
                menu.classList.remove('opacity-100');
                menu.classList.add('transform');
                menu.classList.add('-translate-y-1');

                // Gửi yêu cầu sắp xếp (giả định gửi về server)
                console.log('Sắp xếp theo:', sortValue);
                // TODO: Thêm logic gửi AJAX để sắp xếp danh sách laptop
            });
        });
    });

    // Đóng dropdown khi nhấp ra ngoài
    document.addEventListener('click', (e) => {
        dropdowns.forEach(dropdown => {
            const menu = dropdown.querySelector('.dropdown-menu');
            if (menu && !dropdown.contains(e.target)) {
                menu.classList.add('hidden');
                menu.classList.add('opacity-0');
                menu.classList.remove('opacity-100');
                menu.classList.add('transform');
                menu.classList.add('-translate-y-1');
            }
        });
    });
});
