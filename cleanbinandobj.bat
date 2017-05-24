
for /D /R "." %%G in (BIN.*) DO RMDIR /S /Q "%%G"
for /D /R "." %%G in (OBJ.*) DO RMDIR /S /Q "%%G"
PAUSE