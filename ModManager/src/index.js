import React from 'react';
import { createRoot } from 'react-dom/client';

import App from './components/App';

import 'bootstrap/dist/css/bootstrap.min.css';

// https://getbootstrap.com/docs/5.3/customize/color-modes/
document.body.setAttribute("data-bs-theme", "dark");

createRoot(
    document.getElementById('app')
).render(
    <App />
);