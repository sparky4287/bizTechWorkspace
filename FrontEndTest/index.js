document.addEventListener("DOMContentLoaded", function () {
	const targetModal = document.getElementById("contactUsModal");
	const openModalBtn = document.getElementById("openContactUsModal");
	const closeModalBtn = document.getElementById("closeContactUsModal");

	function openModal() {
		if (targetModal) {
			targetModal.style.display = "block";
		}
	}
    
	function closeModal() {
		if (targetModal) {
			targetModal.style.display = "none";
		}
	}

	if (openModalBtn) {
		openModalBtn.addEventListener("click", openModal);
	}

	if (closeModalBtn) {
		closeModalBtn.addEventListener("click", closeModal);
	}

	window.addEventListener("click", function (event) {
		if (event.target === targetModal) {
			closeModal();
		}
	});
});