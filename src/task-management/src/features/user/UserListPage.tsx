import { useEffect, useState } from "react";
import { User } from "../../types/User";

const UserListPage = () => {
  const [users, setUsers] = useState<User[]>([]);
  const [loading, setLoading] = useState<boolean>(true);
  const [error, setError] = useState<string | null>(null);

  useEffect(() => {
    fetch("https://localhost:7069/api/User/GetUsers")
      .then((response) => {
        if (!response.ok) {
          throw new Error("Server error");
        }
        return response.json();
      })
      .then((data) => {
        setUsers(data);
        setLoading(false);
      })
      .catch((error) => {
        setError(error);
        setLoading(false);
      });
  }, []);

  if (loading) return <div>Loading...</div>;
  if (error) return <div>Error: {error}</div>;

  return (
    <div className="w-full lg:w-1/2">
      <h2 className="text-3xl mb-4 text-left">User List</h2>
      <ul>
        {users.map((user) => (
          <li key={user.id} className="bg-gray-100 p-2 mb-2 rounded shadow">
            <p className="text-lg font-semibold">{user.name}</p>
            <p className="text-sm">{user.email}</p>
          </li>
        ))}
      </ul>
    </div>
  );
};

export default UserListPage;
