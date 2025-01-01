import { Route, Routes, BrowserRouter } from "react-router-dom";
import "./App.css";
import Layout from "./components/Layout";
import { Suspense } from "react";
import { CustomRoutes, RouteConfig } from "./components/CustomRoutes";

function App() {
  return (
    <BrowserRouter>
      <Layout>
        <Suspense fallback={<div>Loading...</div>}>
          <Routes>
            {CustomRoutes.map((route: RouteConfig, index: number) => (
              <Route key={index} path={route.path} element={route.element} />
            ))}
            {/* <Route path="/" element={<ProjectListPage />} />
            <Route path="/project" element={<ProjectListPage />} />
            <Route path="/task" element={<CreateTaskPage />} />
            <Route path="/signup" element={<UserRegistrationPage />} />
            <Route path="/userlist" element={<UserListPage />} /> */}
          </Routes>
        </Suspense>
      </Layout>
    </BrowserRouter>
  );
}

export default App;
