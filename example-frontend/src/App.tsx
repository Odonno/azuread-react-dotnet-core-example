import React, { useEffect, useState } from 'react';
import { getToken } from './adalConfig';
import { User } from './models';

const App: React.FC = () => {
  const [user, setUser] = useState<User>();
  const [values, setValues] = useState<string[]>([]);

  useEffect(() => {
    const headers = { Authorization: `Bearer ${getToken()}` };

    fetch('https://localhost:5001/api/user/current', { headers })
      .then(response => {
        if (response.ok) {
          response.json().then(u => setUser(u));
        } else {
          setUser(undefined);
        }
      });
  }, []);

  useEffect(() => {
    const headers = { Authorization: `Bearer ${getToken()}` };

    fetch('https://localhost:5001/api/values', { headers })
      .then(response => {
        if (response.ok) {
          response.json().then(v => setValues(v));
        } else {
          setValues([]);
        }
      });
  });

  return (
    <div>
      {user && user.isAuthenticated
        ? <div>Authenticated as {user.login}</div>
        : <div>Not authenticated</div>
      }

      <ul>
        {values.map(v =>
          <li key={v}>{v}</li>)
        }
      </ul>
    </div>
  );
}

export default App;
