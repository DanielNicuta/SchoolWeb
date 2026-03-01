(function () {
  // Only guard pages that contain an editor form explicitly marked
  const form = document.querySelector("form[data-dirty-guard='true']");
  if (!form) return;

  let isDirty = false;

  const markDirty = () => { isDirty = true; };
  const clearDirty = () => { isDirty = false; };

  // Mark dirty on any edit
  form.querySelectorAll("input, textarea, select").forEach(el => {
    el.addEventListener("input", markDirty);
    el.addEventListener("change", markDirty);
  });

  // If user saves/submits, don’t warn
  form.addEventListener("submit", clearDirty);

  window.addEventListener("beforeunload", (e) => {
    if (!isDirty) return;
    e.preventDefault();
    e.returnValue = "";
  });

  // Character counters: add data-max="160" on inputs/textarea you care about
  document.querySelectorAll('[data-max]').forEach(el => {
    const max = parseInt(el.getAttribute('data-max'), 10);
    if (!max) return;

    const counter = document.createElement('div');
    counter.className = 'admin-counter';
    el.parentElement.appendChild(counter);

    const update = () => {
      const len = (el.value || '').length;
      counter.textContent = `${len}/${max}`;
      counter.classList.toggle('over', len > max);
    };

    el.addEventListener('input', update, { passive: true });
    update();
  });

  // Optional: JSON formatter for textareas with data-json="true"
  document.querySelectorAll('textarea[data-json="true"]').forEach(el => {
    const btn = document.createElement('button');
    btn.type = 'button';
    btn.className = 'btn btn-sm btn-outline-secondary mt-2';
    btn.textContent = 'Format JSON';

    btn.addEventListener('click', () => {
      try {
        const obj = JSON.parse(el.value);
        el.value = JSON.stringify(obj, null, 2);
      } catch {
        alert('Invalid JSON. Please fix the JSON and try again.');
      }
    });

    el.insertAdjacentElement('afterend', btn);
  });
})();