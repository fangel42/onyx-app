import { QueryClient, QueryClientProvider } from "@tanstack/react-query";
import { ReactQueryDevtools } from "@tanstack/react-query-devtools";
import { RouterProvider, createRouter } from "@tanstack/react-router";
import createStore from "react-auth-kit/createStore";
import useAuthUser from "react-auth-kit/hooks/useAuthUser";
import useAuthHeader from "react-auth-kit/hooks/useAuthHeader";
import AuthProvider from "react-auth-kit";
import { routeTree } from "./routeTree.gen";
import { User } from "./lib/validation/user";

declare module "@tanstack/react-router" {
  interface Register {
    router: typeof router;
  }
}

const isProduction = import.meta.env.PROD;
const store = createStore({
  authName: "_auth",
  authType: "cookie",
  cookieDomain: window.location.hostname,
  cookieSecure: isProduction ? window.location.protocol === "https:" : false,
});

const queryClient = new QueryClient();
const router = createRouter({
  routeTree,
  context: { queryClient, user: null, token: null },
  defaultPreload: "intent",
  defaultPreloadStaleTime: 0,
});

const App = () => {
  return (
    <QueryClientProvider client={queryClient}>
      <AuthProvider store={store}>
        <RouterWithAuth />
        <ReactQueryDevtools initialIsOpen={false} />
      </AuthProvider>
    </QueryClientProvider>
  );
};

export default App;

const RouterWithAuth = () => {
  const user = useAuthUser<User>();
  const token = useAuthHeader();
  const routerContext = { queryClient, user, token };
  return <RouterProvider router={router} context={routerContext} />;
};