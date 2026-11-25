import { apiClient } from "@/lib/api-client";
import { tokenStorage } from "./token-storage";
import { AuthResponse, LoginPayload, RegisterPayload } from "./types";

export const authApi = {
  login: async (payload: LoginPayload): Promise<AuthResponse> => {
    const response = await apiClient<AuthResponse>("/auth/login", {
      method: "POST",
      body: JSON.stringify(payload),
    });

    tokenStorage.setAuthSession(response);

    return response;
  },

  register: async (payload: RegisterPayload): Promise<AuthResponse> => {
    const response = await apiClient<AuthResponse>("/auth/register", {
      method: "POST",
      body: JSON.stringify(payload),
    });

    tokenStorage.setAuthSession(response);

    return response;
  },

  refreshToken: async (refreshToken: string): Promise<AuthResponse> => {
    const response = await apiClient<AuthResponse>("/auth/refresh-token", {
      method: "POST",
      body: JSON.stringify({ refreshToken }),
    });

    tokenStorage.setAuthSession(response);

    return response;
  },

  logout: () => {
    tokenStorage.clearAuthSession();
  },
};
