export enum UserRole {
  User = 1,
  Admin = 2,
}

export interface User {
  id: string;
  email: string;
  role: string;
}

export interface AuthResponse {
  userId: string;
  email: string;
  role: string;
  accessToken: string;
  refreshToken: string;
  refreshTokenExpirationUtc: string;
}

export interface LoginPayload {
  email: string;
  password: string;
}

export interface RegisterPayload {
  email: string;
  password: string;
}

export interface RefreshTokenPayload {
  refreshToken: string;
}