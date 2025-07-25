from setuptools import find_packages, setup

setup(
    name="BancosBrasileiros",
    version="5.0.0",
    description="Brazilian commercial banks list",
    long_description=open("README.md").read(),
    long_description_content_type="text/markdown",
    author="guibranco",
    author_email="opensource@straccini.com",
    url="https://github.com/guibranco/BancosBrasileiros",
    packages=find_packages(where="src"),
    package_dir={"": "src"},
    include_package_data=True,
    classifiers=[
        "Programming Language :: Python :: 3",
        "License :: OSI Approved :: MIT License",
        "Operating System :: OS Independent",
    ],
)
