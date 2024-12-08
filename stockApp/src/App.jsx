// src/App.jsx
import React from 'react';
import { Routes, Route } from 'react-router-dom';
import ResponsiveDrawer from './components/ResponsiveDrawer';
import routes from './Config/RouterConfig'

function App() {
  return (

    <ResponsiveDrawer>
      <Routes>
        {routes.map((route, index) => (
          <Route key={index} path={route.path} element={route.element} />
        ))}
      </Routes>
    </ResponsiveDrawer>
  );
}

export default App;
