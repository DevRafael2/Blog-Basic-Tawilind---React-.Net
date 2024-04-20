import { Navigate, useLocation } from "react-router-dom";
import { useAuth } from "../hooks/useAuth";

export default function ProtectedRoute({
  children,
}: {
  children: JSX.Element;
}) {
  let auth = useAuth();
  let location = useLocation();

  if (!auth || !auth.user) {
    return <Navigate to="/login" state={{ from: location }} replace />;
  }

  return children;
}
