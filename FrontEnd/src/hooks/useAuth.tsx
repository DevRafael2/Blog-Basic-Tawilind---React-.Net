import React, {
  ReactNode,
  createContext,
  useCallback,
  useContext,
  useMemo,
} from "react";
import { useNavigate } from "react-router-dom";
import { useLocalStorage } from "./useLocalStorage";
import { login as authServiceLogin } from "../services/authService";

export interface AuthContextType {
  user: any;
  login: (userName: string, password: string) => Promise<void>;
  logout: () => void;
  getAuthToken: () => string | null; // Nuevo método para obtener el token de autenticación
}

const AuthContext = createContext<AuthContextType | null>(null);

export const AuthProvider = ({ children }: { children: ReactNode }) => {
  const [user, setUser] = useLocalStorage("userData", null);
  const navigate = useNavigate();

  const login = useCallback(
    async (userName: string, password: string) => {
      try {
        const userData = await authServiceLogin(userName, password);
        setUser(userData);
        navigate("/");
      } catch (error) {
        throw new Error("Error");
      }
    },
    [setUser, navigate]
  );

  const logout = useCallback(() => {
    try {
      setUser(null);
      navigate("/", { replace: true });
    } catch (error) {
      throw new Error(
        "An error occurred during logout. Please try again later."
      );
    }
  }, [setUser, navigate]);

  const getAuthToken = useCallback(() => {
    return user ? user.token : null;
  }, [user]);

  const value = useMemo(
    () => ({
      user,
      login,
      logout,
      getAuthToken,
    }),
    [user, login, logout, getAuthToken]
  );

  return <AuthContext.Provider value={value}>{children}</AuthContext.Provider>;
};

export const useAuth = () => {
  return useContext(AuthContext);
};
