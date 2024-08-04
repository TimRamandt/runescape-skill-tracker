import React from 'react'
import ReactDOM from 'react-dom/client'
import App from './App.tsx'
import "./main.css"
import {
  createBrowserRouter,
  RouterProvider,
} from "react-router-dom";
import SyncList from './SyncList.tsx';
import Goals from './Goals.tsx';

const router = createBrowserRouter([
  {
    path: "/",
    element: <App/>,
  },
  {
    path: "/syncs",
    element: <SyncList/>
  },
  {
    path: "/goals",
    element: <Goals/>
  }
]);

ReactDOM.createRoot(document.getElementById('root')!).render(
  <React.StrictMode>
    <RouterProvider router={router} />
  </React.StrictMode>,
)
