import { lazy, ReactNode } from "react";

export interface RouteConfig {
  title: string;
  path: string;
  element: any;
}

const LazyProjectListPage = lazy(
  () => import("../features/project/ProjectListPage")
);
const LazyUserListPage = lazy(() => import("../features/user/UserListPage"));
const LazyUserRegistrationPage = lazy(
  () => import("../features/user/UserRegistrationPage")
);

export const CustomRoutes: RouteConfig[] = [
  {
    title: "Home",
    path: "/",
    element: <LazyProjectListPage />,
  },
  {
    title: "Users",
    path: "/userlist",
    element: <LazyUserListPage />,
  },
  {
    title: "Sign Up",
    path: "/signup",
    element: <LazyUserRegistrationPage />,
  },
];
