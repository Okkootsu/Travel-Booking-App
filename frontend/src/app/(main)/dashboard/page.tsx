"use client";

import { useAuth } from "@/features/auth/AuthContext";
import { useRouter } from "next/navigation";

export default function Dashboard() {
  const { user, logout } = useAuth();
  const router = useRouter();

  const handleLogout = () => {
    logout();
    router.push("/");
    router.refresh();
  };

  return (
    <div className="flex flex-col items-center justify-center gap-3 flex-1">
      <div className="flex flex-col items-center justify-center gap-3">
        <p>Email: {user?.email}</p>
      </div>
      <button className="bg-red-600 hover:bg-red-700 text-white w-fit cursor-pointer transition rounded p-2" onClick={handleLogout}>Çıkış Yap</button>
    </div>
  );
}
