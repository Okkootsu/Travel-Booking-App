import type { Metadata } from "next";
import { Inter } from "next/font/google";
import "./globals.css";
import { Navbar } from "@/components/Navbar";
import { AuthProvider } from "@/features/auth/AuthContext";
import { Toaster } from "react-hot-toast";

const inter = Inter({ subsets: ["latin"] });

export const metadata: Metadata = {
  title: "Travel.io",
  description: "placeholder description", // TODO: add description
};

export default function RootLayout({ children }: LayoutProps<"/">) {
  return (
    <html lang="tr" className={`h-full scroll-smooth`} suppressHydrationWarning>
      <body
        className={`${inter.className} min-h-screen flex flex-col antialiased`}
        suppressHydrationWarning
      >
        <AuthProvider>
          <Toaster
            position="top-center"
            toastOptions={{
              duration: 4000,
              className:
                "text-xs font-semibold rounded-2xl shadow-lg border border-slate-200/80 mt-16",
              style: {
                background: "#ffffff",
                color: "#0f172a",
                padding: "12px 16px",
              },
            }}
          />
          {children}
        </AuthProvider>
      </body>
    </html>
  );
}
