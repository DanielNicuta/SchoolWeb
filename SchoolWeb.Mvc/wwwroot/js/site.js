(function () {
  const nav = document.querySelector(".navbar-main");
  if (!nav) return;

  const onScroll = () => {
    if (window.scrollY > 10) nav.classList.add("scrolled");
    else nav.classList.remove("scrolled");
  };

  window.addEventListener("scroll", onScroll, { passive: true });
  onScroll();
})();