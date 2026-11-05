import type { Metadata } from "next";
import { Inter } from "next/font/google";
import "./globals.css";
import { Navbar } from "@/components/Navbar";

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
        <Navbar />
        <main className="flex-1 flex flex-col">{children}</main>
      </body>
    </html>
  );
}
